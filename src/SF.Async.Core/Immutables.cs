using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{

    using Immutable = ImmutableDictionary<string, IMessageBox>;

    public class Immutables: IData
    {
        public static Immutables Empty { get => new Immutables(); }

        private Immutable _immutable;

        public Immutables()
        {
            _immutable = Immutable.Empty;
            ID = Guid.NewGuid().ToString();
        }

        public Immutables(Immutable immutable)
        {
            _immutable = immutable;
            ID = Guid.NewGuid().ToString();
        }

        public Immutables(IMessageBox messageBox)
        {
            _immutable = Immutable.Empty.Add("origin", messageBox);
            ID = Guid.NewGuid().ToString();
        }


        public string ID { get ;}

        public Immutables Add(string index, IMessageBox message)
        {
            return new Immutables(_immutable.Add(index, message));
        }

        public static Immutables CreateImmutables(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var Serializer = new DataContractJsonSerializer(obj.GetType());
                Serializer.WriteObject(stream, obj);
                stream.Position = 0;
                using (StreamReader sr = new StreamReader(stream))
                {
                    var wrapper = new MessageBox
                    {
                        Type = obj.GetType().FullName,
                        PayLoad = sr.ReadToEnd(),
                    };


                    return new Immutables(wrapper);
                }
            }

        }

    }
}
