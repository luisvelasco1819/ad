package serpis.ad;

import java.util.Scanner;

public class HolaMundo {

	public static void main(String[] args) {
		System.out.println("Hola Mundo desde eclipse con gradle.");
		
		//Scanner scanner = new Scanner(System.in);
		System.out.println("45=" +  "45".matches("-?\\d+"));
		System.out.println("-45=" +  "-45".matches("-?\\d+"));
		System.out.println("+45=" +  "+45".matches("-?\\d+"));
		System.out.println("45a=" +  "45a".matches("-?\\d+"));
		System.out.println("ab=" +  "ab".matches("-?\\d+"));
		
	}

}
