//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamApp.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OptionMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OptionMaster()
        {
            this.ExamQuestions = new HashSet<ExamQuestion>();
        }
    
        public long OptionID { get; set; }
        public long QuestionID { get; set; }
        public string OptionLabel { get; set; }
        public string OptionDesc { get; set; }
        public bool Correct { get; set; }
        public Nullable<int> MarksForOption { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual QuizMaster QuizMaster { get; set; }
    }
}