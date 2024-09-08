import java.util.Scanner;

public class SumTwoNums02 {

    public static void main(String[] args){
        Scanner scan = new Scanner(System.in);

        //int firstNum = Integer.parseInt(scan.nextLine());
        //int secondNum = Integer.parseInt(scan.nextLine());

        double firstNum = scan.nextDouble();
        double secondNum = scan.nextDouble();

        double result = firstNum + secondNum;

        System.out.printf("%.2f", result);
    }
}
