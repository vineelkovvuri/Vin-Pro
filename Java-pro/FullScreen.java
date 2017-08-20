import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;



public class FullScreen extends JFrame{
	JButton jb = new JButton("Close");
	public FullScreen(GraphicsDevice gd){
		super(gd.getDefaultConfiguration());
		setLayout(null);
		jb.setBounds(100, 100, 70, 30);
		add(jb);
		jb.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
				GraphicsDevice gs = ge.getDefaultScreenDevice();
				gs.setFullScreenWindow(null);
				System.exit(0);
			}
		});
		setUndecorated(true);
		setDefaultCloseOperation(3);
		try {
			gd.setFullScreenWindow(this);
			this.validate();

			Thread.currentThread().suspend();
		} catch (Exception e1) {

			e1.printStackTrace();
		}finally{
			gd.setFullScreenWindow(null);
		}

	}

	public static void main(String []args){
		GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
		GraphicsDevice gs = ge.getDefaultScreenDevice();
		new FullScreen( gs);
	}
}

