﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.Attributes
{
    //указываем, что данный атрибут можно прописать только в Property
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string title = "", bool visible = true, int width = 0, 
            GridViewAutoSize gridViewAutoSize = GridViewAutoSize.None, bool isUseAutoSize = false, string format = "")
        {
            Title = title;
            Visible = visible;
            Width = width;
            GridViewAutoSize = gridViewAutoSize;
            IsUseAutoSize = isUseAutoSize;
			Format = format;
		}

        public string Title { get; private set; }

        public bool Visible { get; private set; }

        public int Width { get; private set; }

        public GridViewAutoSize GridViewAutoSize { get; private set; }

        public bool IsUseAutoSize { get; private set; }

		public string Format { get; private set; }
	}
}
