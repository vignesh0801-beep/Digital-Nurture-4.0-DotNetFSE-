using System;

namespace FactoryMethodPatternExample
{
    interface IDocument
    {
        void Open();
        string GetType();
    }

    class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a Word document.");
        }

        public string GetType()
        {
            return "Word";
        }
    }

    class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a PDF document.");
        }

        public string GetType()
        {
            return "PDF";
        }
    }

    class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening an Excel document.");
        }

        public string GetType()
        {
            return "Excel";
        }
    }

    abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();

        public void Display()
        {
            IDocument doc = CreateDocument();
            Console.WriteLine($"{doc.GetType()} document created by {this.GetType().Name}");
            doc.Open();
        }
    }

    class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    class ExcelFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    class Program
    {
        static void Main()
        {
            DocumentFactory wordFactory = new WordFactory();
            DocumentFactory pdfFactory = new PdfFactory();
            DocumentFactory excelFactory = new ExcelFactory();

            wordFactory.Display();
            pdfFactory.Display();
            excelFactory.Display();
        }
    }
}
