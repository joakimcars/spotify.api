﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSpotify.Web.Models.ViewModels
{
    public class IndexVm
    {
        public List<SelectedSongsVm> SelectedSongs { get; set; }
        public IList<CategoryVm> Categories { get; set; }
    }
}
