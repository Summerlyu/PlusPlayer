using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayer
{
    class ZipCode
    {
        public string province,city,zipcode,areacode;
        public ZipCode( string city,string province,string zipcode,string areacode)
        { 
            this.province = province;
            this.city = city;
            this.zipcode = zipcode;
            this.areacode = areacode;
        }
        public override string ToString()
        {
            return province+","+city;
        }
        
    }
}
