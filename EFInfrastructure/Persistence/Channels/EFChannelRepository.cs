using AutoMapper;
using DomainModel.Channels;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.Channels
{
    public class EFChannelRepository : IChannelRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFChannelRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChannelDataModel, Channel>()
                    .ReverseMap()
                    .IncludeMembers(s => s.ChannelInfo);
                cfg.CreateMap<ChannelInfo, ChannelDataModel>();
            });
            _mapper = config.CreateMapper();
        }

        public Channel Find(string id)
        {
            var dataModel = _context.Channels.SingleOrDefault(x => x.Id == id);
            if (dataModel == null) return null;

            var channel = _mapper.Map<Channel>(dataModel);
            return channel;
        }

        public List<Channel> FindAll()
        {
            var channels = _context.Channels.Select(x => _mapper.Map<Channel>(x)).ToList();
            return channels;
        }

        public void Create(Channel channel)
        {
            var found = _context.Channels.SingleOrDefault(x => x.Id == channel.Id);
            if (found != null) return;

            var dataModel = _mapper.Map<ChannelDataModel>(channel);
            _context.Add(dataModel);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var found = _context.Channels.SingleOrDefault(x => x.Id == id);
            if (found == null) return;

            _context.Channels.Remove(found);
            _context.SaveChanges();
        }
    }
}
