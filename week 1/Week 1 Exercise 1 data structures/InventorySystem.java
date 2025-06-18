import java.util.HashMap;
import java.util.Scanner;

class Product {
    public String productId, productName;
    public int quantity;
    public double price;

    public Product(String productId, String productName, int quantity, double price) {
        this.productId = productId;
        this.productName = productName;
        this.quantity = quantity;
        this.price = price;
    }

    public String toString() {
        return productId + " - " + productName + " | Qty: " + quantity + " | ₹" + price;
    }
}

class InventoryManager {
    private static InventoryManager instance = null;
    private HashMap<String, Product> inventory = new HashMap<>();

    private InventoryManager() {}

    public static InventoryManager getInstance() {
        if (instance == null) {
            instance = new InventoryManager();
        }
        return instance;
    }

    public void addProduct(Product product) {
        if (inventory.containsKey(product.productId)) {
            System.out.println("Product already exists.");
        } else {
            inventory.put(product.productId, product);
            System.out.println("Product added.");
        }
    }

    public void updateProduct(String productId, Integer quantity, Double price) {
        Product p = inventory.get(productId);
        if (p != null) {
            if (quantity != null) p.quantity = quantity;
            if (price != null) p.price = price;
            System.out.println("Product updated.");
        } else {
            System.out.println("Product not found.");
        }
    }

    public void deleteProduct(String productId) {
        if (inventory.remove(productId) != null) {
            System.out.println("Product deleted.");
        } else {
            System.out.println("Product not found.");
        }
    }

    public void displayProduct(String productId) {
        Product p = inventory.get(productId);
        if (p != null) {
            System.out.println(p);
        } else {
            System.out.println("Product not found.");
        }
    }
}

public class InventorySystem {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        InventoryManager manager = InventoryManager.getInstance();

        while (true) {
            System.out.println("\n1. Add\n2. Update\n3. Delete\n4. Display\n5. Exit");
            System.out.print("Choose: ");
            int choice = sc.nextInt();
            sc.nextLine(); // consume newline

            if (choice == 1) {
                System.out.print("Enter ID: ");
                String id = sc.nextLine();
                System.out.print("Enter Name: ");
                String name = sc.nextLine();
                System.out.print("Enter Quantity: ");
                int qty = sc.nextInt();
                System.out.print("Enter Price: ");
                double price = sc.nextDouble();
                sc.nextLine();
                manager.addProduct(new Product(id, name, qty, price));

            } else if (choice == 2) {
                System.out.print("Enter ID to update: ");
                String id = sc.nextLine();
                System.out.print("Enter new quantity (-1 to skip): ");
                int qty = sc.nextInt();
                System.out.print("Enter new price (-1 to skip): ");
                double price = sc.nextDouble();
                sc.nextLine();
                manager.updateProduct(id, qty == -1 ? null : qty, price == -1 ? null : price);

            } else if (choice == 3) {
                System.out.print("Enter ID to delete: ");
                String id = sc.nextLine();
                manager.deleteProduct(id);

            } else if (choice == 4) {
                System.out.print("Enter ID to view: ");
                String id = sc.nextLine();
                manager.displayProduct(id);

            } else if (choice == 5) {
                break;
            }
        }

        sc.close();
    }
}
