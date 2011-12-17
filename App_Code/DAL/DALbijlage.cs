using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALbijlage
/// </summary>
public class DALbijlage
{
    dc_databankDataContext dc = new dc_databankDataContext();

    public IList<Bijlage> selectAll()
    {
        var result = (from o in dc.Bijlages
                      select o).ToList();
        return result;
    }
}