//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KontonisAG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kategorien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategorien()
        {
            this.Artikel = new HashSet<Artikel>();
        }
    
        public long Kategorie_Nr { get; set; }
        public string Kategoriename { get; set; }
        public string Beschreibung { get; set; }
        public string Abbildung { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artikel> Artikel { get; set; }
    }
}
