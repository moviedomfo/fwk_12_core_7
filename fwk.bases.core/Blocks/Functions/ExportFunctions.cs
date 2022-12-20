﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fwk.HelperFunctions
{
  
    /// <summary>
    /// 
    /// </summary>
    public class ExportFunctions
    {
    

        #region Private Methods
        private static string GenerarEncabezado(string psz_NombreTab)
        {
            StringBuilder woStrAux = new StringBuilder();
            woStrAux.Append(@"<?xml version=""1.0""?>");
            woStrAux.Append(@"<?mso-application progid=""Excel.Sheet""?>");
            woStrAux.Append(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""");
            woStrAux.Append(@" xmlns:o=""urn:schemas-microsoft-com:office:office""");
            woStrAux.Append(@" xmlns:x=""urn:schemas-microsoft-com:office:excel""");
            woStrAux.Append(@" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""");
            woStrAux.Append(@" xmlns:html=""http://www.w3.org/TR/REC-html40"">");
            woStrAux.Append(@" <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office""> ");
            woStrAux.Append(@"  <Author>InfoSys</Author>");
            woStrAux.Append(@"  <Company>Infoxel</Company>");
            woStrAux.Append(@" </DocumentProperties>");
            woStrAux.Append(@" <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">");
            woStrAux.Append(@"  <WindowHeight>9210</WindowHeight>");
            woStrAux.Append(@"  <WindowWidth>15195</WindowWidth>");
            woStrAux.Append(@"  <WindowTopX>0</WindowTopX>");
            woStrAux.Append(@"  <WindowTopY>60</WindowTopY>");
            woStrAux.Append(@"  <ProtectStructure>False</ProtectStructure>");
            woStrAux.Append(@"  <ProtectWindows>False</ProtectWindows>");
            woStrAux.Append(@" </ExcelWorkbook>");
            woStrAux.Append(@" <Styles>");
            woStrAux.Append(@"  <Style ss:ID=""Default"" ss:Name=""Normal"">");
            woStrAux.Append(@"   <Alignment ss:Vertical=""Bottom""/>");
            woStrAux.Append(@"   <Borders/>");
            woStrAux.Append(@"   <Font/>");
            woStrAux.Append(@"   <Interior/>");
            woStrAux.Append(@"   <NumberFormat/>");
            woStrAux.Append(@"   <Protection/>");
            woStrAux.Append(@"  </Style>");
            woStrAux.Append(@" </Styles>");
            woStrAux.Append(@" <Worksheet ss:Name=""" + psz_NombreTab + @""">");
            return woStrAux.ToString();

        }





        private static string GenerarPie()
        {
            StringBuilder woStrAux = new StringBuilder();
            woStrAux.Append(@"  </Table>");
            woStrAux.Append(@"  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">");
            woStrAux.Append(@"   <PageSetup>");
            woStrAux.Append(@"    <Header x:Margin=""0""/>");
            woStrAux.Append(@"    <Footer x:Margin=""0""/>");
            woStrAux.Append(@"    <PageMargins x:Bottom=""0.984251969"" x:Left=""0.78740157499999996""");
            woStrAux.Append(@"     x:Right=""0.78740157499999996"" x:Top=""0.984251969""/>");
            woStrAux.Append(@"   </PageSetup>");
            woStrAux.Append(@"   <Print>");
            woStrAux.Append(@"    <ValidPrinterInfo/>");
            woStrAux.Append(@"    <HorizontalResolution>1200</HorizontalResolution>");
            woStrAux.Append(@"    <VerticalResolution>1200</VerticalResolution>");
            woStrAux.Append(@"   </Print>");
            woStrAux.Append(@"   <Selected/>");
            woStrAux.Append(@"   <ProtectObjects>False</ProtectObjects>");
            woStrAux.Append(@"   <ProtectScenarios>False</ProtectScenarios>");
            woStrAux.Append(@"  </WorksheetOptions>");
            woStrAux.Append(@" </Worksheet>");
            woStrAux.Append(@"</Workbook>");
            return woStrAux.ToString();
        }

        private static string GenerarCabeceraTabla(int pi_Filas, int pi_Columnas, double pd_Ancho)
        {
            StringBuilder woStrAux = new StringBuilder();
            woStrAux.Append(@"  <Table ss:ExpandedColumnCount=""" + pi_Columnas + @""" ss:ExpandedRowCount=""" + pi_Filas + @""" x:FullColumns=""1""");
            woStrAux.Append(@"   x:FullRows=""1"" ss:DefaultColumnWidth=""60"">");
            woStrAux.Append(@"   <Column ss:Width=""" + pd_Ancho + @""" ss:Span=""2""/>");
            return woStrAux.ToString();
        }

        private static string AbrirFila()
        {
            return @"   <Row>";
        }

        private static string CerrarFila()
        {
            return "   </Row>";
        }

        private static string CrearCelda(string psz_Texto)
        {
            StringBuilder woStrAux = new StringBuilder();
            woStrAux.Append(@"    <Cell><Data ss:Type=""String"">");
            woStrAux.Append(psz_Texto + @"</Data></Cell>");
            return woStrAux.ToString();
        }
        #endregion

    }
}
