import java.util.*;

class Product {
    int productId;
    String productName;
    String category;

    public Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    public String toString() {
        return productId + ": " + productName + " [" + category + "]";
    }
}

interface SearchStrategy {
    Product search(Product[] products, int productId);
}

class LinearSearch implements SearchStrategy {
    public Product search(Product[] products, int productId) {
        for (Product p : products) {
            if (p.productId == productId) return p;
        }
        return null;
    }
}

class BinarySearch implements SearchStrategy {
    public Product search(Product[] products, int productId) {
        int l = 0, r = products.length - 1;
        while (l <= r) {
            int m = (l + r) / 2;
            if (products[m].productId == productId) return products[m];
            if (products[m].productId < productId) l = m + 1;
            else r = m - 1;
        }
        return null;
    }
}

class SearchFactory {
    public static SearchStrategy get(String type) {
        if (type.equalsIgnoreCase("linear")) return new LinearSearch();
        if (type.equalsIgnoreCase("binary")) return new BinarySearch();
        return null;
    }
}

public class fac {
    static Scanner scan = new Scanner(System.in);

    static void print(String s) {
        System.out.println(s);
    }

    public static void main(String[] args) {
        ArrayList<Product> productList = new ArrayList<>();

        print("Enter product details (type 'stop' as ID to finish):");
        while (true) {
            print("Enter product ID:");
            String idInput = scan.nextLine();
            if (idInput.equalsIgnoreCase("stop")) break;

            int id = Integer.parseInt(idInput);

            print("Enter product name:");
            String name = scan.nextLine();

            print("Enter category:");
            String cat = scan.nextLine();

            productList.add(new Product(id, name, cat));
        }

        Product[] products = productList.toArray(new Product[0]);

        print("Enter product ID to search:");
        int idToSearch = scan.nextInt();

        SearchStrategy linear = SearchFactory.get("linear");
        Product res1 = linear.search(products, idToSearch);
        print("Linear Search: " + (res1 != null ? res1.toString() : "Not Found"));

        Arrays.sort(products, (a, b) -> Integer.compare(a.productId, b.productId));
        SearchStrategy binary = SearchFactory.get("binary");
        Product res2 = binary.search(products, idToSearch);
        print("Binary Search: " + (res2 != null ? res2.toString() : "Not Found"));
    }
}
