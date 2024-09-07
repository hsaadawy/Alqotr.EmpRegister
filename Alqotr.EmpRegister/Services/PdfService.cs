namespace Alqotr.EmpRegister.Services
{
    using Alqotr.EmpRegister.DAL;
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using System.IO;

    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

      

        
    }

}
