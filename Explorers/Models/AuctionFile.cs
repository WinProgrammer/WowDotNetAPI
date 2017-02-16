using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AuctionFile
    {
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "lastModified")]
        public long LastModified { get; set; }

        [IgnoreDataMember]
        private Auctions _auctions;

        [DataMember(Name = "auctions", IsRequired = false)]
        public Auctions Auctions {
            get
            {
                if (_auctions != null)
                    return _auctions;

                Auctions auctions;

                WowExplorer.TryGetData<Auctions>(URL, out auctions);

                return (_auctions = auctions);
            }
            set { _auctions = value; }
        }
    }
}
