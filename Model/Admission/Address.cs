//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Admission
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.EducationOrganizations = new HashSet<EducationOrganization>();
            this.Entrants = new HashSet<Entrant>();
            this.ContragentOrganizations = new HashSet<ContragentOrganization>();
            this.ContragentPersons = new HashSet<ContragentPerson>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> TownId { get; set; }
        public Nullable<int> LocalityId { get; set; }
        public Nullable<int> StreetId { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual District District { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual Region Region { get; set; }
        public virtual Street Street { get; set; }
        public virtual Town Town { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationOrganization> EducationOrganizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrant> Entrants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContragentOrganization> ContragentOrganizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContragentPerson> ContragentPersons { get; set; }
    }
}
