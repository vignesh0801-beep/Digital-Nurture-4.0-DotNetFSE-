public class FactoryMethodPatternExample {

    interface Document {
        void open();
        String getType();
    }

    static class WordDocument implements Document {
        public void open() {
            System.out.println("Opening a Word document.");
        }
        public String getType() {
            return "Word";
        }
    }

    static class PdfDocument implements Document {
        public void open() {
            System.out.println("Opening a PDF document.");
        }
        public String getType() {
            return "PDF";
        }
    }

    static class ExcelDocument implements Document {
        public void open() {
            System.out.println("Opening an Excel document.");
        }
        public String getType() {
            return "Excel";
        }
    }

    static abstract class DocumentFactory {
        public abstract Document createDocument();
        public void display() {
            Document doc = createDocument();
            System.out.println(doc.getType() + " document created by " + getClass().getSimpleName());
            doc.open();
        }
    }

    static class WordFactory extends DocumentFactory {
        public Document createDocument() {
            return new WordDocument();
        }
    }

    static class PdfFactory extends DocumentFactory {
        public Document createDocument() {
            return new PdfDocument();
        }
    }

    static class ExcelFactory extends DocumentFactory {
        public Document createDocument() {
            return new ExcelDocument();
        }
    }

    public static void main(String[] args) {
        DocumentFactory wordFactory = new WordFactory();
        DocumentFactory pdfFactory = new PdfFactory();
        DocumentFactory excelFactory = new ExcelFactory();

        wordFactory.display();
        pdfFactory.display();
        excelFactory.display();
    }
}
