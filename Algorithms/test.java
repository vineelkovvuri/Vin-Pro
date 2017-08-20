import java.io.FileOutputStream;
import java.io.PrintStream;

public class test {
	public synchronized static void CS(String threadName){
			System.out.println("Thread Name:"+threadName);
	}
	public static void main(String[] args) throws Exception {
		System.setOut(new PrintStream(new FileOutputStream("d:\\out.txt",false)));
		Thread t1 = new Thread(new Runnable(){
			public void run(){
				int i = 0;
				//while(i++ < 1)
				Sample.CS("1 i="+i);
			}
		});
		/*
		Thread t2 = new Thread(new Runnable(){
			public void run(){
				int j = 0;
				//while(j++ < 1)
					Sample.CS("2 j="+j);
			}
		});*/
		t1.start();
		//t2.start();
	}
}
