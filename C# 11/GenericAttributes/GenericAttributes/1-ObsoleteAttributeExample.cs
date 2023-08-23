using System.Diagnostics.CodeAnalysis;

namespace GenericAttributesExample1
{
    class ObsoleteAttributeExample
    {
        public ObsoleteAttributeExample()
        {
            var bsc = new BarberShopCustomer
            {
                FirstName = "Jimmy",
                LastName = "Dean",
                //FirstVisit = DateTime.Now,
                //HaircutPreference = HairStyle.Mullet,
                MustachePreference = MustacheStyle.Handlebar,
            };
            bsc.RecordNewVisit();
        }
    }

    enum HairStyle
    {
        MiddlePart,
        CrewCut,
        Sideburns,
        [Obsolete($"No longer offered. Suggest using Shaved instead.", true)]
        Mullet,
        Shaved,
    }

    enum MustacheStyle
    {
        None,
        Walrus,
        Chevron,
        Pencil,
        [Obsolete("To be removed soon.. turns customers into old-timey villains.")]
        Handlebar,
    }

    class BarberShopCustomer
    {
        public string FirstName { get; set; } = string.Empty;

        [AllowNull]
        public string LastName { get; set; }

        [Obsolete("This value is no longer tracked and will be removed in an upcoming release.", true)]
        public DateTime FirstVisit { get; set; }

        public DateTime LastVisit { get; private set; }

        public HairStyle HaircutPreference { get; set; }

        public MustacheStyle MustachePreference { get; set; }

        [Obsolete($"Recommend using {nameof(RecordNewVisitMoreAccurately)}() instead. This method will be removed in an upcoming release.")]
        public void RecordNewVisit()
        {
            LastVisit = DateTime.Today;
        }

        public void RecordNewVisitMoreAccurately()
        {
            LastVisit = DateTime.Now;
        }
    }
}
