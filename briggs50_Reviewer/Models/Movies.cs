using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace briggs50_Reviewer.Models
{
    // XML Stuff
    [XmlRoot("Movies")]
    public class Movies
    {
        [XmlElement("Movie")]
        public List<Movie> movies;
    }
}