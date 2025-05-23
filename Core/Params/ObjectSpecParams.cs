using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Params
{
    /// <summary>
    /// This class holds query parameters for filtering, paging, and sorting objects.
    /// </summary>
    public class ObjectSpecParams
    {
        // restrict the amount of data user query fro database
        private const int MaxPageSize = 50; //Ensures users can’t request more than 50 items per page to avoid overloading the server
        public int PageIndex { get; set; } = 1; // Current Page Index, Defaults to page 1 (the first page). Used for paginated results.
        private int _pageSize = 5; // Default number of items per page is 5.it can be modified but is constrained by MaxPageSize.

            /// <summary>
           ///  Gets or sets the number of items per page.
           /// If a user tries to set it to more than 50, it automatically sets it to 50.
           ///  This is a common technique for input validation.
          /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value >MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>
        ///  A private field to hold the search string used for filtering
        ///  results, typically by naming or description.
        /// </summary>
        // filter the data by name
        private string? _search;

        /// <summary>
        /// Ensuring the search term is always stored in lowercase for case-insensitive search.
        /// If _search is null, it returns an empty string by default to avoids null reference issues.
         /// </summary>
        public string Search
        {
            get => _search ??  "";
            set
            {
                _search = value.ToLower();
            }
        }


        // sort the obj
        /// <summary>
        /// Accepts sorting instructions like "name", "priceAsc", "dateDesc", etc. the
        ///Optional string? means it can be null
       ///Usually used to dynamically sort the query result.
       /// </summary>
        public string? Sort { get; set; } 
    }
}
