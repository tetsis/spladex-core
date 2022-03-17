using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace DomainModel.EditingHistories
{
    public class EditingHistory
    {
        public EditingHistory(
            string userId,
            OperationType operationType,
            ContentType contentType,
            object content)
        {
            Id = Guid.NewGuid().ToString();
            UserId = userId;
            OperationType = operationType;
            ContentType = contentType;

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            options.Converters.Add(new JsonStringEnumConverter());

            Content = JsonSerializer.Serialize(content, options);
            CreateTime = DateTime.Now;
        }

        public string Id { get; }
        public string UserId { get; }
        public OperationType OperationType { get; }
        public ContentType ContentType { get; }
        public string Content { get; }
        public DateTime CreateTime { get; }
    }
}
