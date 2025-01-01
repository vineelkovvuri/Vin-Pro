import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.io.File;
import java.util.Random;

public class Main {

    static final int MAX_COLUMNS = 3;
    static final int MAX_ROWS = 3;
    static JFrame jfMainWindow;
    static JPanel jpTitles[][]; // fixed
    static int boards[][][] = {
            {
                    {7, 8, 2},
                    {5, 6, 1},
                    {4, 3, 0},
            },
            {
                    {5, 8, 7},
                    {3, 6, 2},
                    {4, 1, 0},
            },
            {
                    {8, 6, 2},
                    {5, 4, 7},
                    {1, 3, 0},
            },
            {
                    {8, 6, 5},
                    {3, 2, 7},
                    {4, 1, 0},
            },
    };
    static int board[][];
    static Color tileBorderColor = new Color(187, 173, 160);
    static Color tileBackgroundColor = new Color(205, 193, 180);
    static JLabel jlTimer = new JLabel();
    static Timer timer;
    static int seconds;
    public static void main(String[] args) {

        Random random = new Random();
        board = boards[random.nextInt(0, boards.length)];

        jfMainWindow = new JFrame();
        jfMainWindow.setSize(400, 600);
        jfMainWindow.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        jfMainWindow.setLayout(null);

        jpTitles = new JPanel[MAX_ROWS][MAX_COLUMNS];

        for (int i = 0, y = 20; i < MAX_ROWS; i++, y += 50) {
            for (int j = 0, x = 20; j < MAX_COLUMNS; j++, x += 50) {
                jpTitles[i][j] = new JPanel();
                jpTitles[i][j].setBorder(BorderFactory.createLineBorder(tileBorderColor, 5));
                jpTitles[i][j].setBackground(tileBackgroundColor);
                jpTitles[i][j].setSize(45, 45);
                jpTitles[i][j].setLocation(x, y);
                jpTitles[i][j].putClientProperty("i", i);
                jpTitles[i][j].putClientProperty("j", j);

                JLabel jlNumber = new JLabel("0");
                jlNumber.setFont(new Font("Arial", Font.BOLD, 28));
                jpTitles[i][j].add(jlNumber);

                jpTitles[i][j].addMouseListener(new MouseListener() {
                    @Override
                    public void mouseClicked(MouseEvent e) {
                        process(e);
                    }

                    @Override
                    public void mousePressed(MouseEvent e) {

                    }

                    @Override
                    public void mouseReleased(MouseEvent e) {

                    }

                    @Override
                    public void mouseEntered(MouseEvent e) {

                    }

                    @Override
                    public void mouseExited(MouseEvent e) {

                    }
                });

                jfMainWindow.add(jpTitles[i][j]);
            }
        }

        updateBoard();

        jlTimer.setText("This is label");
        jlTimer.setSize(200, 200);
        jlTimer.setFont(new Font("Arial", Font.BOLD, 28));
        jlTimer.setLocation(20, 250);
        jfMainWindow.add(jlTimer);

        timer = new Timer(1000, (e) -> {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int secs = seconds % 60;
            jlTimer.setText(hours + ":" + minutes + ":" + secs);
            seconds++;
        });
        timer.start();

        jfMainWindow.setVisible(true);
    }

    private static void updateBoard() {
        for (int i = 0; i < MAX_ROWS; i++) {
            for (int j = 0; j < MAX_COLUMNS; j++) {
                JLabel jlNumber = (JLabel)(jpTitles[i][j].getComponent(0));
                if (board[i][j] != 0)
                    jlNumber.setText(board[i][j] + "");
                else
                    jlNumber.setText("");
            }
        }
    }

    public static void process(MouseEvent e) {
        System.out.println("Mouse clicked");

        if (e.getSource() instanceof JPanel) {
            JPanel clickedPanel = (JPanel) e.getSource();
            int i = (int) clickedPanel.getClientProperty("i");
            int j = (int) clickedPanel.getClientProperty("j");

            update(i, j);
        }
    }

    public static void update(int i, int j) {

        // left
        if (j - 1 >= 0) {
            if (board[i][j-1] == 0) {
                swap(i, j, i, j - 1);
                updateBoard();
                playSound();
                findWinner();
                return;
            }
        }

        // right
        if (j + 1 < MAX_COLUMNS) {
            if (board[i][j+1] == 0) {
                swap(i, j, i, j + 1);
                updateBoard();
                playSound();
                findWinner();
                return;
            }
        }

        // top
        if (i - 1 >= 0) {
            if (board[i - 1][j] == 0) {
                swap(i, j, i - 1, j);
                updateBoard();
                playSound();
                findWinner();
                return;
            }
        }

        // bottom
        if (i + 1 < MAX_ROWS) {
            if (board[i + 1][j] == 0) {
                swap(i, j, i + 1, j);
                updateBoard();
                playSound();
                findWinner();
                return;
            }
        }
    }

    private static void swap(int i, int j, int i1, int j1) {
        int temp = board[i][j];
        board[i][j] = board[i1][j1];
        board[i1][j1] = temp;
    }

    private static void playSound()
    {
        try {
            AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(Main.class.getResourceAsStream("Click.wav"));
            Clip clip = AudioSystem.getClip();
            clip.open(audioInputStream);
            clip.start();
        } catch(Exception e) {}
    }

    private static void findWinner()
    {
        int winnerBoard[][] = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 0},
        };

        for (int i = 0; i < MAX_ROWS; i++) {
            for (int j = 0; j < MAX_COLUMNS; j++) {
                if (board[i][j] != winnerBoard[i][j]) {
                    return;
                }
            }
        }

        JOptionPane.showMessageDialog(null, "You won the game");
    }

}