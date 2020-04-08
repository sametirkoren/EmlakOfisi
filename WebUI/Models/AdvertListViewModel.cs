using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataTransferObjects;
using Entities.Concrete;

namespace WebUI.Models
{
    public class AdvertListViewModel
    {
        public List<AdvertForListDto> Adverts { get;  set; }
        
    }
}
