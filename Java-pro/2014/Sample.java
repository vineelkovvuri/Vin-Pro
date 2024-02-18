
public class Sample {
    public static void main(String[] args) throws Exception {
		add();
    }
	static class Inner {
		static private int n;
	}
	public static void add()
	{
		System.out.println(Inner.n);
	}
}

