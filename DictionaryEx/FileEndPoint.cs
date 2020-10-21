using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryEx
{
    public class FileEndPoint
    {
        private string _ipAddress;
        private int _port;

        public FileEndPoint()
        {
        }

        public FileEndPoint(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public string IpAddress
        {
            get => _ipAddress;
            set => _ipAddress = value;
        }

        public override string ToString()
        {
            return $"{nameof(_ipAddress)}: {_ipAddress}, {nameof(_port)}: {_port}";
        }

        public int Port
        {
            get => _port;
            set => _port = value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FileEndPoint) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_ipAddress != null ? _ipAddress.GetHashCode() : 0) * 397) ^ _port;
            }
        }
    }
}
