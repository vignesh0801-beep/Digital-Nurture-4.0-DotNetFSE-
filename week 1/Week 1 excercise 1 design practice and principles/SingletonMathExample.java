import java.util.Scanner;

public class SingletonMathExample {

    static class MathLogger {
        private static MathLogger instance;

        private MathLogger() {
            System.out.println("MathLogger instance created.");
        }

        public static MathLogger getInstance() {
            if (instance == null) {
                instance = new MathLogger();
            }
            return instance;
        }

        public int add(int a, int b) {
            int result = a + b;
            System.out.println("[ADD] " + a + " + " + b + " = " + result);
            log("Performed addition");
            return result;
        }

        public int multiply(int a, int b) {
            int result = a * b;
            System.out.println("[MULTIPLY] " + a + " * " + b + " = " + result);
            log("Performed multiplication");
            return result;
        }

        public void log(String message) {
            System.out.println("[LOG]: " + message);
            System.out.println("Logger instance hash: " + this.hashCode());
        }
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        MathLogger logger = MathLogger.getInstance();

        System.out.print("Enter first number: ");
        int num1 = sc.nextInt();

        System.out.print("Enter second number: ");
        int num2 = sc.nextInt();

        System.out.print("Enter operation (add/multiply): ");
        String op = sc.next().toLowerCase();

        switch (op) {
            case "add":
                logger.add(num1, num2);
                break;
            case "multiply":
                logger.multiply(num1, num2);
                break;
            default:
                logger.log("Invalid operation.");
        }

        System.out.println("Logger used: " + logger.hashCode());
        sc.close();
    }
}
