using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

using G1ANT.Language;


namespace $rootnamespace$
{
    [Structure(Name = "", Default = default(TValue))]
    class $safeitemrootname$ : StructureTyped<TValue>
	{
        public $safeitemrootname$(TValue value, string format = "", AbstractScripter scripter = null) :
            base(value, format, scripter)
        { }

        public $safeitemrootname$(object value, string format = null, AbstractScripter scripter = null) : 
            base(value, format, scripter)
        { }

        protected override TValue Parse(string value, string format = null)
        {
            throw new NotImplementedException();
        }
    }
}
