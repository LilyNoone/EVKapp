using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLbijlage
/// </summary>
public class BLLbijlage
{
    DALbijlage DALbijlage = new DALbijlage();

    public IList<Bijlage> selectAll()
    {
        return DALbijlage.selectAll();
    }
}