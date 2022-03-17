using AutoMapper;
using DomainModel.EditingHistories;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.EditingHistories
{
    public class EFEditingHistoryRepository : IEditingHistoryRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFEditingHistoryRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditingHistoryDataModel, EditingHistory>()
                    .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public List<EditingHistory> FindRange(int offset, int limit)
        {
            var editingHistories = _context.EditingHistories.Skip(offset).Take(limit).Select(x => _mapper.Map<EditingHistory>(x)).ToList();
            return editingHistories;
        }

        public int GetCount()
        {
            int count = _context.EditingHistories.Count();
            return count;
        }

        public void Create(EditingHistory editingHistory)
        {
            var found = _context.EditingHistories.SingleOrDefault(x => x.Id == editingHistory.Id);
            if (found != null) return;

            var dataModel = _mapper.Map<EditingHistoryDataModel>(editingHistory);
            _context.Add(dataModel);
            _context.SaveChanges();
        }
    }
}
