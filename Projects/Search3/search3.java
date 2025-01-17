/*
 *  This is a file searching program written in JAVA for
 *  searching a file in the requested drive or directory.
 *
 *         Concepts used
 *         1.Generics
 *         2.Enchanced for loop
 *         3.Swings
 *         4.MultiThreading
 *         5.Collections
 *         6.Regular Expressions
 *         7.Files
 *         8.Java's Printing Functionality
 *         9.Makes native calls(Not using JNI) to windows shell32.dll from Runtime class
 *
 *         Packages Used
 *         1.java.awt;
 *         2.java.io;
 *         3.java.nio;
 *         4.java.util;
 *         5.java.util.regex;
 *         6.javax.print
 *         7.javax.print.attribute
 *         8.javax.swing
 *
 *  
 *                                              This Program is Written By
 *                                          K.Vineel Kumar Reddy  B.Tech II/IV IT
 *                                          Gayatri Vidya Parishad College of Engg.
 *                                          Vishakapatnam,Andhra Pradesh.
 *                                          INDIA.
 *  NOTE : This program works only for
 *         JRE >=1.5 and Windows NT(make use of Rundll32.exe and shell32.dll)
 *
 */
//Last Modified: Mon Oct 22 2007 12:26:39 AM 

//~--- JDK imports ------------------------------------------------------------

import java.awt.Color;
import java.awt.Container;
import java.awt.Cursor;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.print.PageFormat;
import java.awt.print.Printable;
import java.awt.print.PrinterJob;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import java.nio.channels.FileChannel;

import java.util.Date;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Vector;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.print.attribute.HashPrintRequestAttributeSet;

import javax.swing.BorderFactory;
import javax.swing.DefaultListModel;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPopupMenu;
import javax.swing.JScrollPane;
import javax.swing.JSeparator;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.JWindow;
import javax.swing.SwingUtilities;
import javax.swing.UIManager;

class copyTo implements MouseListener {
    private JMenu                        jm[] = new JMenu[30];
    private JMenu                        copyTo;
    private Hashtable<JMenuItem, String> h;
    private JList                        jli;
    private JPopupMenu                   jp;

//  ==========================================================      
    public void copyTo(JPopupMenu jp, JList jli) {
        this.jp  = jp;
        this.jli = jli;
        h        = new Hashtable<JMenuItem, String>();
        copyTo   = new JMenu("Copy To");
        jp.add(copyTo);

		int i = 0;
        for (File f : File.listRoots()) {
            copyTo.add(jm[i] = new JMenu("" + f.getPath()));
            jm[i].addMouseListener(this);
            search(f, jm[i++]);    // only directories in c:\ d:\ e:\ are added(not recursively)
        }
        jp.add(new JScrollPane());
    }

//  ==========================================================
    private int countDir(File f) {
        int count = 0;
        for (File f1 : f.listFiles()) 
            if (f1.isDirectory())count++;
        return count;
    }

//  ==========================================================
    private void search(File f, JMenu jm) {    // For adding the dirs in to the menu for the given path
        JMenu     test;
        int       i = 0;
        JMenuItem testm;

        if ((f.listFiles() == null) || (countDir(f) == 0)) {    // creates "copy here" menuitem if f is empty
            // or it contain's only files not dir
            testm = new JMenuItem("Copy Here");
            h.put(testm, f.getPath());       // add "copy" menu to hashtable
            testm.addMouseListener(this);    // add listener to "copy here" item
            jm.add(testm);                   // add "copy here" menu to jm menu
        } else {                             // if it contains directories
            for (File f1 : f.listFiles()) 
                if (f1.isDirectory()) {
                    if (i == 0) {            // first of all we need to add "copy here"
                        // in the menu
                        testm = new JMenuItem("Copy Here");
                        h.put(testm, f.getPath());
                        testm.addMouseListener(this);
                        jm.add(testm);
                        i++;
                        jm.add(new JSeparator());
                    }                                          // this will be executed only once
                    jm.add(test = new JMenu(f1.getName()));    // as f1 is a dir this creates a JMenu
                    h.put(test, f1.getPath());
                    test.addMouseListener(this);
                }
        }
    }

//  ==========================================================
    public void mouseClicked(MouseEvent e) {}

//  ==========================================================
    public void mousePressed(MouseEvent e) {    // File Copying starts Here
        try {
            FileChannel in  = new FileInputStream((String) jli.getSelectedValue()).getChannel();
            FileChannel out = new FileOutputStream(h.get(e.getSource()) + "\\"
                                  + new File((String) jli.getSelectedValue()).getName()).getChannel();

            search3.s.setTitle("File Copying is in Progress Please Wait...");
            out.transferFrom(in, 0, in.size());    // file copying process
            out.close();
            out.close();
            search3.s.setTitle("File copying sucessfully completed");
            JOptionPane.showMessageDialog(null, "Sucessfully Copied");
        } catch (Exception ee) {
            JOptionPane.showMessageDialog(
                null,
                h.get(e.getSource())
                + " ERROR : possible reasons\n1.You no sufficent rights to copy here \n2.you have not selected an Entry\n3.Destination Device is not ready");
        }
    }

//  ==========================================================
    public void mouseReleased(MouseEvent e) {}
//  ==========================================================
    public void mouseEntered(MouseEvent e) {
        if (e.getSource() instanceof JMenu) {
            search3.s.setTitle(h.get(e.getSource()));    // just for showing the path seleting by the user in the title bar
            if (((JMenu) e.getSource()).getItemCount() == 0) 
                search(new File(h.get(e.getSource())), (JMenu) e.getSource());
        }
    }

//  ==========================================================
    public void mouseExited(MouseEvent e) {}
}

//==========================================================
public class search3 extends JFrame implements ActionListener, Runnable, Printable, MouseListener {
    // ==========================================================
    static int                flag             = 0;
    private static final long serialVersionUID = -2223554793047033860L;
    private static final int
        R                                      = 198,
        G                                      = 178,
        B                                      = 141;

    // ==========================================================
    static search3           s;
    int                      flag1     = 1;
    private JWindow          jw        = null;
    private Matcher          m         = null;
    private Pattern          p         = null;
    private JCheckBox        jcb[]     = new JCheckBox[2];
    private JFileChooser     j         = new JFileChooser();
    private File[]           drives    = new File[20];
    private boolean          continue_ = true,
                             Windows   = false;
    private JCheckBox        cb[]      = new JCheckBox[20];
    public String            SearchFileName, path;
    private Container        c;
    int                      count, countf, depth, high;
    private DefaultListModel dlm;
    private JButton          jb1, jb2, jb3, jb4, jb5, jb6, print;
    private JLabel           jl1, jl2, jl3, jl5, jl6;
    private JList            jli;
    private JMenuItem        jm1, jm2, jm3, jm4, jm5, jm6, jm7;
    private JPopupMenu       jp1, jp2;
    private JScrollPane      jsp;
    private JTextArea        jta2, jta1;
    private JTextField       jtf1, jtf2, jtf3;
    private StringBuffer     sb;
    private Thread           t;
    private Toolkit          tk;

    // =======================================================================
    private void initiate() {
        c = getContentPane();
        c.setLayout(null);
        setTitle("File Searching  Program By Vineel Kumar Reddy");
        tk = getToolkit();
        c.addMouseListener(this);
        setIconImage(tk.createImage("sun.png"));

        Dimension d = tk.getScreenSize();

        setBounds((d.width - 780) / 2, (d.height - 500) / 2, 780, 500);
        setResizable(false);
        c.setBackground(new Color(R, G, B));

        if (System.getProperty("java.version").compareTo("1.5") < 0) {
            JOptionPane.showMessageDialog(
                    null, "ERROR:\nJava Version is : " + System.getProperty("java.version")
                    + "\nJava version should be >=1.5\nBecause this program make use of Enhanced For loop and Generics.", "Java version should be >=1.5", JOptionPane
                        .INFORMATION_MESSAGE);
            System.exit(-1);
        }

        // Enable Theme
        if (System.getProperty("os.name").equalsIgnoreCase("Windows XP")) {
            Windows = true;
            try {
                UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
                SwingUtilities.updateComponentTreeUI(this);
            } catch (Exception e) {
				System.out.println("Error initializing native theme");
			}
        }

        // Check whether the OS is Windows are not
        /*
         * if(System.getProperty("os.name").toLowerCase().indexOf("windows")==-1){
         *       JOptionPane.showMessageDialog(null, "Sorry I am not designed for this Lovely  "+System.getProperty("os.name") +" Operating System"
         *                       ,"Contact my BOSE......!!!!!",JOptionPane.INFORMATION_MESSAGE);
         *       System.exit(-1);
         * }
         */
        jb1 = new JButton(new ImageIcon("go.gif"));
        c.add(jb1);
        jb1.setMnemonic('O');
        jb1.setDefaultCapable(true);
        jb1.setBounds(250, 20, 70, 20);
        jb1.addActionListener(this);
        jb1.addMouseListener(this);
        jb4 = new JButton("Browse", new ImageIcon("browse.png"));
        c.add(jb4);
        jb4.setMnemonic('B');
        jb4.setBounds(330, 20, 100, 20);
        jb4.addActionListener(this);
        jb4.addMouseListener(this);
        jb2 = new JButton("Clear", new ImageIcon("clear.png"));
        c.add(jb2);
        jb2.setMnemonic('L');
        jb2.setBounds(440, 20, 100, 20);
        jb2.addActionListener(this);
        jb2.addMouseListener(this);
        jb5 = new JButton("Stop", new ImageIcon("stop.gif"));
        c.add(jb5);
        jb5.setMnemonic('S');
        jb5.setBounds(550, 20, 85, 20);
        jb5.addActionListener(this);
        jb5.addMouseListener(this);
        jb3 = new JButton("Exit", new ImageIcon("exit.png"));
        c.add(jb3);
        jb3.setMnemonic('X');
        jb3.setBounds(645, 20, 80, 20);
        jb3.addActionListener(this);
        jb3.addMouseListener(this);
        drives = File.listRoots();

        for (int i = 0; i < drives.length; i++) {
            cb[i] = new JCheckBox(drives[i].getPath());
            cb[i].setMnemonic(drives[i].getPath().charAt(0));
            cb[i].setBackground(new Color(R, G, B));
            cb[i].setBounds(20 + 40 * i, 50, 40, 20);
            cb[i].addMouseListener(this);
            c.add(cb[i]);
        }

        jcb[0] = new JCheckBox("Hidden");
        jcb[0].setMnemonic('I');
        c.add(jcb[0]);
        jcb[0].setBackground(new Color(R, G, B));
        jcb[0].setBounds(20, 350, 100, 20);
        jcb[0].addMouseListener(this);
        jcb[1] = new JCheckBox("Case sensitive");
        jcb[1].setMnemonic('T');
        c.add(jcb[1]);
        jcb[1].setBackground(new Color(R, G, B));
        jcb[1].setBounds(150, 350, 150, 20);
        jcb[1].addMouseListener(this);
        jp2 = new JPopupMenu();
        jp2.add(jm4 = new JMenuItem("Copy", new ImageIcon("copy.png")));
        jm4.addActionListener(this);
        jp2.add(jm4);
        jp2.add(jm5 = new JMenuItem("Paste", new ImageIcon("paste.png")));
        jm5.addActionListener(this);
        jp2.add(jm5);
        jtf1 = new JTextField(10);
        jtf1.add(jp2);
        jtf1.addActionListener(this);
        c.add(jtf1);
        jtf1.setBounds(105, 20, 140, 20);
        jtf1.setComponentPopupMenu(jp2);
        jtf1.addMouseListener(this);
        jtf2 = new JTextField(10);
        c.add(jtf2);
        jtf2.setEditable(false);
        jtf2.addMouseListener(this);
        jtf2.setBounds(530, 100, 150, 20);
        jtf3 = new JTextField(10);
        c.add(jtf3);
        jtf3.setEditable(false);
        jtf3.addMouseListener(this);
        jtf3.setBounds(530, 130, 150, 20);
        jta2 = new JTextArea();    // help content
        jsp  = new JScrollPane(jta2);
        jsp.setBounds(360, 160, 350, 130);
        jta2.setLineWrap(true);
        jta2.addMouseListener(this);
        jta2.setText("This is a search program which searches for a file " + "directories ");
        jta2.setCursor(Cursor.getDefaultCursor());
        jta2.setFocusable(false);
        jta2.setForeground(new Color(57, 118, 177));
        jta2.setFont(new Font("Helvetica", Font.BOLD, 15));
        jta2.setBackground(new Color(R, G, B));
        jsp.setBackground(new Color(R, G, B));
        jsp.setBorder(BorderFactory.createTitledBorder(BorderFactory.createBevelBorder(5), "Help:"));
        c.add(jsp);
        jl1 = new JLabel("Name of the File:");
        jl1.setDisplayedMnemonic('N');
        jl1.setLabelFor(jtf1);
        c.add(jl1);
        jl1.setBounds(20, 20, 120, 20);
        jl2 = new JLabel("Files Searched so far:");
        c.add(jl2);
        jl2.setBounds(360, 100, 130, 20);
        jl3 = new JLabel("Files found so far:");
        c.add(jl3);
        jl3.setBounds(360, 130, 120, 20);
        jta1 = new JTextArea();    // path of the searching files
        jta1.setLineWrap(true);
        jta1.setFont(new Font("Helvetica", Font.PLAIN, 12));
        jta1.setCursor(Cursor.getDefaultCursor());
        jta1.setFocusable(false);
        jta1.setBackground(new Color(R, G, B));
        jta1.setBounds(20, 300, 730, 40);
        c.add(jta1);
        jl5 = new JLabel("");    // depth of dir
        c.add(jl5);
        jl5.setToolTipText("Gives the relative depth of the \ndirectories from the parent directory");
        jl5.setBounds(360, 350, 350, 20);
        jl6 = new JLabel(new ImageIcon("javalogo.gif"));
        c.add(jl6);
        jl6.addMouseListener(this);
        jl6.setBounds(690, 360, 50, 90);
        print = new JButton("Print", new ImageIcon("print.png"));
        print.setBounds(570, 390, 90, 30);
        print.setMnemonic('P');
        print.setEnabled(false);
        print.addActionListener(this);
        print.addMouseListener(this);
        c.add(print);
        dlm = new DefaultListModel();
        dlm.ensureCapacity(100000);
        jli = new JList(dlm);

        MouseListener mouseListener = new MouseAdapter() {
            public void mouseClicked(MouseEvent e) {
                try {
                    if ((e.getClickCount() == 2) && Windows) 
                        Runtime.getRuntime().exec("rundll32 SHELL32.DLL,ShellExec_RunDLL  " + jli.getSelectedValue());
                } catch (Exception ee) {
                    JOptionPane.showMessageDialog(search3.this, "ERROR AT MOUSE CLICK");
                }
            }
        };

        jli.addMouseListener(mouseListener);
        jli.addMouseListener(this);
        jb6 = new JButton("Path of the files");
        jp1 = new JPopupMenu();
        jli.setComponentPopupMenu(jp1);
        c.add(jb6);
        jb6.addMouseListener(this);
        jb6.setEnabled(true);
        jb6.setBounds(20, 100, 301, 20);
        jsp = new JScrollPane(jli);
        c.add(jsp);
        jsp.setBounds(20, 121, 300, 170);
        initializepopup();
        SwingUtilities.updateComponentTreeUI(this);
        setVisible(true);
    }

    // ====================================================================
    private void initializepopup() {
        jm1 = new JMenuItem("Open Containing Folder ", new ImageIcon("home.gif"));
        jp1.add(jm1);
        jm1.addActionListener(this);
        jm2 = new JMenuItem("Open it", new ImageIcon("stop.gif"));
        jp1.add(jm2);
        jm2.addActionListener(this);
        jm3 = new JMenuItem("Properties", new ImageIcon("bulb.gif"));
        jp1.add(jm3);
        jm3.addActionListener(this);
        jm6 = new JMenuItem("Delete", new ImageIcon("delete.png"));
        jp1.add(jm6);
        jm6.addActionListener(this);
        jm7 = new JMenuItem("Rename ", new ImageIcon("rename.png"));
        jp1.add(jm7);
        jm7.addActionListener(this);

        copyTo ct = new copyTo();    // CopyTo Object

        ct.copyTo(jp1, jli);    // Call for CopyTo Function
        c.add(jp1);
        c.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent e) {
                if (e.isPopupTrigger()) 
                    jp1.show(search3.this, e.getX(), e.getY());
            }
        });
    }

    // ===========================================================
    // This search method is based on Breadthwise Tree Traversal
    // ==========================================================
    private void search(File f) {    // search takes a file object
        try {
            File[] temp = null;
            try {
                temp = f.listFiles();
            } catch (SecurityException se) {
                System.out.println("Security Exception at: " + f.getPath());
                return;
            }

            if (temp != null) {
                Vector<File> v = new Vector<File>();    // this is for holding the directories
                for (File f1 : temp) 
                    if (continue_) {                    // if the user click the stop button stop here
                        if (!jcb[0].isSelected()) 
                            if (f1.isHidden())          // if the user didn't selected the hidden check box
                                continue;				// avoid searching hidden files. 
								                        // so I skipped them using continue statement	                        

                        m = p.matcher(f1.getName());                   // returns Matchers class of java.util.regex
                        if (m.find()) {                                // returns true if the given file name is found inside the searching file name
                            jtf3.setText("" + (++countf));             // => number of files found 
                            dlm.add(dlm.getSize(), f1.getPath());      // => adding path of files found to JList
                            jli.validate();
                        }

                        jta1.setText("Searching: " + f1.getPath());    // => displays the currently searching file path
                        jtf2.setText("" + (++count));                  // => files searched so far

                        if (f1.isDirectory() && f1.getPath().equals(f1.getCanonicalPath())) // Check whether f1 is a link or not
                            v.add(f1);                                 // if f1 is a dir --> keep it in vector
                    }

               for(File dir :v){        		    	                // iterating through the vector as we are going to enter into a dir
                    depth++;                    	    	            // high is a variable which keep track the highest depth.
                    if (high < depth)high = depth;                      // It should be varied only if it's value is less than
										                    			// that of it's previous value
                    jl5.setText("Depth of the directory: " + depth);
                    search(dir);  										// recursively call the search
                    jl5.setText("Depth of the directory: " + (--depth));    // after comming out of the directory decrement depth.
                }
            }
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this,
                                          e.getMessage() + "\nERROR : This is in search Method:\n"
                                          + "possible resons\n" + "1.The drive is not ready...!\n"
                                          + "2.The file pointer is null");
        }
    }

    // ==========================================================
    private void pattern(String s) {
        // Replaces . with \\.
        sb = new StringBuffer("^");

        for (int k = 0; k < s.length(); k++) 
            if (s.charAt(k) != '.') sb.append("" + s.charAt(k));
             else sb.append("\\.");
            
        s = sb.toString();

        // Replaces * with .*
        sb = new StringBuffer();

        for (int k = 0; k < s.length(); k++) 
            if (s.charAt(k) != '*') sb.append("" + s.charAt(k));
            else sb.append(".*");

        s = sb.toString();

        // Replaces ? with .
        sb = new StringBuffer();

        for (int k = 0; k < s.length(); k++) 
            if (s.charAt(k) != '?')sb.append("" + s.charAt(k));
            else sb.append(".");

        sb.append("$");
        SearchFileName = sb.toString();
        setTitle(jtf1.getText());
    }

    // ==========================================================
    public void actionPerformed(ActionEvent e) {
        try {

            /* /<--- */
            t = new Thread(this);    // this statement is here instead of inside the below

            /* | */

            // if statement because browse button can also use it

            /* | */

            // see below

            /* | */
            if ((e.getSource() == jb1) || (e.getSource() == jtf1)) {    // go

                /* | */
                if (!jtf1.getText().trim().equals("")) {                // verify whether file text field is empty

                    /* | */
                    clear();    // clean all the text fields and table except file

                    /* | */

                    // text field so clean method doesn't have jtf1.setText("");

                    /* | */
                    t.start();    // if jtf1 is not empty swan a new thead and run it

                    /* | */
                } else

                /* | */
                {
                    JOptionPane.showMessageDialog(this,

                    /* | */
                    "Enter a File name ", "",

                    /* | */
                    JOptionPane.ERROR_MESSAGE);

                    /* | */
                    jtf1.setText("");

                    /* | */
                }

                /* | */
            }                              // end go

            /* | */
            if (e.getSource() == jb2) {    // clear

                /* | */
                jtf1.setText("");

                /* | */
                clear();

                /* | */
            }

            /* | */
            if (e.getSource() == jb3)     // exit
                /* | */  System.exit(0);

            /* | */
            if (e.getSource() == jb4) {    // browse

                /* | */
                int ref = 0;

                /* | */
                j.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);

                /* | */
                clear();

                /* | */
                ref = j.showOpenDialog(this);

                /* | */
                if (ref == JFileChooser.CANCEL_OPTION) return;
                else path = j.getSelectedFile().getPath();

				if (jtf1.getText().trim().equals("")) {
                    JOptionPane.showMessageDialog(this,"Enter the name of the File", "",
                    JOptionPane.ERROR_MESSAGE);
                    jtf1.setText("");
                }

                /* \ */
                else 
                    /* \---> */
                    t.start();
            }                              // end browse

            if (e.getSource() == jb5) {    // stop
                continue_ = false;
                print.setEnabled(true);
                System.gc();
            }                              // end stop

            if (e.getSource() == print) {
                PrinterJob job = PrinterJob.getPrinterJob();

                job.setPrintable(this);

                HashPrintRequestAttributeSet att = new HashPrintRequestAttributeSet();

                if (job.printDialog(att)) {
                    try {
                        job.print();
                    } catch (Exception p) {
                        JOptionPane.showMessageDialog(this, "ERROR PRINTING");
                    }
                }
            }

            if (e.getSource() == jm1) {    // parent
                try {
                    if (Windows) 
                        Runtime.getRuntime().exec("rundll32 SHELL32.DLL,ShellExec_RunDLL   "
                                                  + new File((String) jli.getSelectedValue()).getParent());
                     else 
                        JOptionPane.showMessageDialog(search3.this, "Not Implemented For this OS");
                } catch (Exception ee) {
                    JOptionPane.showMessageDialog(search3.this, "First Select an Entry and Then Right Click the Mouse");
                }
            }                              // end parent
            if (e.getSource() == jm2) {    // child
                try {
                    Runtime.getRuntime().exec("rundll32 SHELL32.DLL,ShellExec_RunDLL   " + jli.getSelectedValue());
                } catch (Exception ee) {
                    JOptionPane.showMessageDialog(search3.this, "First Select an Entry and Then Right Click the Mouse");
                }
            }                              // end child

            if (e.getSource() == jm3) {    // properties
                try {
                    File f = new File((String) jli.getSelectedValue());

					if (jw != null) jw.dispose();
                     else jw = new JWindow();

                    jw.setLayout(null);
                    jw.getContentPane().setBackground(new Color(R, G, B));
                    jw.setBounds(360 + getX(), getY() + 125, 380, 200);

                    JButton jb = new JButton("Close");

                    jb.setBounds(50, 160, 100, 20);
                    jw.add(jb);
                    jb.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent ae) {
                            search3.this.jw.dispose();
                        }
                    });

                    JTextArea jta = new JTextArea();

                    jta.setFocusable(false);
                    jta.setFont(new Font("Helvetica", Font.PLAIN, 13));
                    jta.setCursor(Cursor.getDefaultCursor());
                    jta.setBackground(new Color(R, G, B));
                    jta.setLineWrap(true);
                    jta.setText("Name: " + f.getName() + "\nPath: " + f.getPath() + "\nSize: " + f.length() + " Bytes"
                                + "\nLastModified: " + new Date(f.lastModified()) + "\nFile: " + f.isFile()
                                + "\nDirectory: " + !f.isFile());
                    jta.setBounds(50, 20, 270, 130);
                    jw.add(jta);
                    jw.setVisible(true);
                } catch (Exception ee) {
                    JOptionPane.showMessageDialog(search3.this, "First Select an Entry and Then Right Click the Mouse");
                }
            }    // end properties

            if (e.getSource() == jm4) {
                jtf1.selectAll();
                jtf1.copy();
            }

            if (e.getSource() == jm5) {
                jtf1.setText("");
                jtf1.paste();
            }

            if (e.getSource() == jm6) {      // delete
                if (JOptionPane.YES_OPTION == JOptionPane.showConfirmDialog(this, "Are You Sure To Delete It...")) {
                    try {
                        File f = new File((String) jli.getSelectedValue());

                        if (f.isFile()) {    // is the file to be deleted is dir or file
                            boolean b = f.delete();

                            if (b) {
                                dlm.remove(jli.getSelectedIndex());
                                JOptionPane.showMessageDialog(this, "The File is sucessfully deleted");
                            } else JOptionPane.showMessageDialog(this, "You do not have right permission to deleted");
                            
                        } else {
                            int i =
                                JOptionPane.showConfirmDialog(this,
                                    "Your are trying to delete a directory would you like to delete its contents Recursively");
                            if (i == JOptionPane.YES_OPTION) {
                                delete(f);
                                dlm.remove(jli.getSelectedIndex());
                                f.delete();
                            }
                        }
                    } catch (Exception e1) {
                        JOptionPane.showMessageDialog(
                            null,
                            " ERROR : possible reasons\n1.you have not selected an Entry\n2.File is being used by other process");
                    }
                }
            }

            if (e.getSource() == jm7) {    // rename
                try {
                    File   f = new File((String) jli.getSelectedValue());
                    String s = JOptionPane.showInputDialog(this, "Enter the new File name:");

                    if ((s != null) &&!s.trim().equals("")) {
                        boolean b = f.renameTo(new File(f.getParent() + "/" + s));

                        if (b) {
                            int x = 0;

                            dlm.remove(x = jli.getSelectedIndex());
                            dlm.add(x, f.getParent() + "\\" + s);
                            jli.validate();
                            JOptionPane.showMessageDialog(this, "The File is sucessfully Renamed");
                        } else JOptionPane.showMessageDialog(this, "The operation failed");
                    }
                } catch (Exception e2) {
                    JOptionPane.showMessageDialog(
                        null,
                        " ERROR : possible reasons\n1.you have not selected an Entry\n2.File is being used by other process");
                }
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }    // end of first try catch
    }

    // ==========================================================
    private void delete(File f) {
        for (File f1 : f.listFiles()) {
            if (f1.isDirectory())delete(f1);    // delete (f1) is my own function where as f1.delete() is in predefined  File class
            f1.delete();
        }
    }

    // ==========================================================
    private void clear() {
        setTitle("File Searching  Program By Vineel Kumar Reddy");
        jb6.setText("Path of the files");
        jtf2.setText("");
        jtf3.setText("");
        print.setEnabled(false);
        dlm.removeAllElements();
        path      = "";
        count     = 0;
        countf    = 0;
        depth     = 0;
        high      = 0;
        continue_ = true;
    }

    public void mouseEntered(MouseEvent c) {
        if (c.getSource() instanceof JCheckBox) {
            for (int i = 0; i < drives.length; i++) 
                if (c.getSource() == cb[i]) 
                    jta2.setText("  Select this to search in " + drives[i].getPath() + "  Drive \n"
                                 + "  or else press ALT+" + drives[i].getPath().charAt(0));

            if (c.getSource() == jcb[0])jta2.setText("  Select this to search in  hidden folders\n " + "  or else press ALT+I ");
            if (c.getSource() == jcb[1]) jta2.setText(" Select this to make  search  case sensitive\n" + "  or else press ALT+T");

		}

        // =================================
        if (c.getSource() == jb1)jta2.setText("  Click this to start the search or \n" + "  else press ALT+O");

        if (c.getSource() == jb2)jta2.setText("  Click this to clear the table and \n" + "  text field contents or else press\n "
                         + "  ALT+L ");

        if (c.getSource() == jb3) jta2.setText("  Click this to stop the search and \n" + "  close this program or else press \n"
                         + "  ALT+X");

        if (c.getSource() == jb4)jta2.setText("  Click this to search inside a \n" + "  particular directory or else \n" + "  press ALT+B");

        if (c.getSource() == jb5)jta2.setText("  Click this to stop the search or \n" + "  else press ALT+S");

        if (c.getSource() == jb6) jta2.setText("");

        if (c.getSource() == print)jta2.setText("  Click this to have a print out of \n" + "  the file paths  found or else \n"
                         + "  press ALT+P");
        if (c.getSource() == jtf1) jta2.setText("Enter the name of the file it can also search\n regular patterns");

		if (c.getSource() == jtf2) jta2.setText("Number of files searched");

        if (c.getSource() == jtf3)jta2.setText("Number of files Found");

        if (c.getSource() == jta2)jta2.setText(
                "This program is coded by K.Vineel Kumar\n" + " Reddy II/IV IT . " + "Thank you for using my \n"
                + " program if you find any bugs or suggestions please post them to vineel567@yahoo.co.in ");

        if (c.getSource() == this.c) jta2.setText("");
        
        if (c.getSource() == jli)jta2.setText("This will list out the file paths whose file\n" + " names matches the given file name\n"
                         + " (regular expression)");

		if (c.getSource() == jl6)jta2.setText("This is not just what JAVA can do");
        
    }

    public int print(Graphics g, PageFormat pg, int page) {
        Graphics2D g2 = (Graphics2D) g;

        g2.translate(pg.getImageableX(), pg.getImageableY());
        if (page >= 2)return Printable.NO_SUCH_PAGE;
		for (int i = 0; i < dlm.getSize(); i++)g2.drawString(dlm.getElementAt(i).toString(), 10, 10 * (i + 1));
        return Printable.PAGE_EXISTS;
    }

    public static void main(String args[]) {
        s = new search3();
        s.initiate();
        s.setDefaultCloseOperation(3);
    }

    // ==========================================================
    private boolean selected() {
        int k = 0;
        for (int i = 0; i < drives.length; i++) 
            if (!cb[i].isSelected()) k++;
        if ((k != drives.length) ||!path.equals("")) 
            return true;
        return false;
    }

    // ==========================================================
    private void setTrueOrFalse(boolean b) {
        jtf1.setEnabled(b);
        jb2.setEnabled(b);
        jb4.setEnabled(b);

        for (int i = 0; i < drives.length; i++) 
            cb[i].setEnabled(b);

        jcb[0].setEnabled(b);
        jcb[1].setEnabled(b);
        jb1.setEnabled(b);
        print.setEnabled(b);

        if (b == true) jb6.setText("Select an entry and right click the mouse");
         else jb6.setText("Path of the Files found");

        jl5.setText("Highest depth of the Directory is: " + high);
    }

    // ==========================================================
    public void run() {
        pattern(jtf1.getText().trim());
        if (jcb[1].isSelected()) p = Pattern.compile(SearchFileName);
        else p = Pattern.compile(SearchFileName, Pattern.CASE_INSENSITIVE);
        jli.removeAll();
        if (selected()) {
            try {
                setTrueOrFalse(false);
                if (path.equals("")) {
                    continue_ = true;
                    for (int i = 0; i < drives.length; i++) 
                        if (cb[i].isSelected() && isDriveReady(drives[i])) 
                            search(drives[i]);
                } else {
                    continue_ = true;
                    search(new File(path));
                }
                setTrueOrFalse(true);
                if (continue_) jta1.setText("Search completed sucessfully");
                 else jta1.setText("Search stopped sucessfully");
            } catch (Exception e) {
                JOptionPane.showMessageDialog(this, "Your CD drive(s) is(are) not ready", "",
                                              JOptionPane.ERROR_MESSAGE);
            }
        } else JOptionPane.showMessageDialog(this, "Select any Drive", "", JOptionPane.ERROR_MESSAGE);
    }

    private boolean isDriveReady(File f) {
        try {
            int i = f.listFiles().length;
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    // ==========================================================
    public void mouseClicked(MouseEvent e) {}

    public void mousePressed(MouseEvent e) {}

    public void mouseReleased(MouseEvent e) {}

    public void mouseExited(MouseEvent e) {}
}

//==========================================================

/*
Finally a big thanks to the creators of Eclipse 3.1
Which Helped me a lot in Coding this Program.
REQUEST: If you Know how to create custom GUI components
in C# (like the GUI of windows media player 10).Please tell me
how to do that  because as the fashion saying goes,
if a person is poorly dressed you notice the clothes,
but if a person is well dressed you notice the person.
sugesstions are always welcome at  vineel567@yahoo.co.in
                                    By
                        K.Vineel Kumar Reddy.
*/
