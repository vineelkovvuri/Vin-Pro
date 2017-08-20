using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Media;
namespace Maze
{
    public partial class MazeMain : Form
    {
        Random r = new Random();
        Cell[,] cells = new Cell[MazeGlobalProperties.MaxCells , MazeGlobalProperties.MaxCells];
        int foodX = 7 , foodY = 1;
        int startX = 0 , startY = 0;
        #region Mat
        int[,] col = {  //Coloums
                        //0 1 2 3 4 5 6 7 8
                        { 1,0,0,0,0,0,0,0,0}, //0
                        { 0,1,1,1,0,0,1,0,0}, //1
                        { 1,0,0,1,1,0,1,0,0}, //2
                        { 0,0,1,0,0,0,0,1,0}, //3
                        { 0,0,0,1,0,1,0,0,0}, //4
                        { 0,0,0,0,1,0,0,1,0}, //5
                        { 0,1,0,0,0,0,0,0,0}, //6
                        { 1,0,0,1,0,0,1,0,0}, //7
                        { 0,0,1,0,0,0,0,0,0}, //8
                        { 0,0,0,0,0,0,0,1,0}, //9
                     };
        int[,] row = {
                        //Rows
                        //0 1 2 3 4 5 6 7 8 9
                        { 0,1,0,0,0,0,0,0,0,0}, //0
                        { 0,1,0,0,1,0,0,1,0,0}, //1
                        { 1,0,0,1,0,0,1,0,0,0}, //2
                        { 1,0,0,0,0,0,1,0,1,0}, //3
                        { 1,0,1,0,0,1,0,0,0,0}, //4
                        { 1,0,0,0,1,0,0,0,1,0}, //5
                        { 1,1,1,0,1,0,0,0,0,0}, //6
                        { 0,0,1,1,0,0,1,0,0,0}, //7
                        { 0,0,0,0,0,0,1,0,0,0}, //8
                      };
        #endregion
        public MazeMain()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void CreateCells()
        {
            int m , n;
            for( int i = 0 ; i < MazeGlobalProperties.MaxCells ; i++ )
                for( int j = 0 ; j < MazeGlobalProperties.MaxCells ; j++ )
                    cells[i , j] = new Cell();

            m = col.GetLength( 0 );
            n = col.GetLength( 1 );

            for( int i = 0 ; i < m ; i++ )
                for( int j = 0 ; j < n ; j++ )
                {
                    if( col[i , j] == 1 )
                        cells[i , j].right = true;

                    if( col[i , n - j - 1] == 1 )
                        cells[i , n - j].left = true;
                }

            m = row.GetLength( 0 );
            n = row.GetLength( 1 );

            for( int i = 0 ; i < m ; i++ )
                for( int j = 0 ; j < n ; j++ )
                {
                    if( row[i , j] == 1 )
                        cells[i , j].down = true;

                    if( row[m - i - 1 , j] == 1 )
                        cells[m - i , j].top = true;
                }

            for( int i = 0 ; i < MazeGlobalProperties.MaxCells ; i++ )
                for( int j = 0 ; j < MazeGlobalProperties.MaxCells ; j++ )
                {
                    cells[i , j].visited = false;
                    cells[i , j].i = i;
                    cells[i , j].j = j;
                }
        }

        private void MazeMain_Paint( object sender , PaintEventArgs e )
        {
            Graphics g = e.Graphics;
            //BackGround
            HatchBrush hb = new HatchBrush( HatchStyle.DiagonalBrick , Color.Gainsboro , Color.GhostWhite );
            g.FillRectangle( hb , this.ClientRectangle );
            hb.Dispose();

            SolidBrush sb = new SolidBrush( Color.Black );
            Pen p = new Pen( sb , 4 );
            g.DrawRectangle( p , 30 , 30 , 10 * 35 , 10 * 35 );
            p.Dispose();

            p = new Pen( sb , 2 );

            for( int i = 0 ; i < MazeGlobalProperties.MaxCells ; i++ )
                for( int j = 0 ; j < MazeGlobalProperties.MaxCells - 1 ; j++ )
                    if( col[i , j] == 0 ) g.DrawLine( p , 30 + 35 + 35 * j , 30 + 35 * i , 30 + 35 + 35 * j , 30 + 35 + 35 * i );

            for( int i = 0 ; i < MazeGlobalProperties.MaxCells - 1 ; i++ )
                for( int j = 0 ; j < MazeGlobalProperties.MaxCells ; j++ )
                    if( row[i , j] == 0 ) g.DrawLine( p , 30 + 35 * j , 30 + 35 + 35 * i , 30 + 35 + 35 * j , 30 + 35 + 35 * i );


            //Paint the Header..........
            int ii = 0;
            for( ii = 0 ; ii < MazeGlobalProperties.MaxCells ; ii++ )
                g.DrawString( ii + "" , this.Font , sb , new PointF( 30 + 15 + 35 * ii , 10 ) );
            g.DrawString( "  X" , this.Font , sb , new PointF( 30 + 15 + 35 * ii , 10 ) );

            for( ii = 0 ; ii < MazeGlobalProperties.MaxCells ; ii++ )
                g.DrawString( ii + "" , this.Font , sb , new PointF( 10 , 30 + 15 + 35 * ii ) );
            g.DrawString( "Y" , this.Font , sb , new PointF( 10 , 30 + 15 + 35 * ii ) );

            p.Dispose();
            sb.Dispose();

            sb = new SolidBrush( Color.Red );
            g.FillRectangle( sb , 33 + 35 * foodX , 33 + 35 * foodY , 30 , 30 );
            sb.Dispose();

            //Paint the bottom Strip

            LinearGradientBrush lgb = new LinearGradientBrush( new Point( 0 , this.Height - 75 ) , new Point( this.Width , this.Height - 75 ) , Color.FromArgb( 61 , 149 , 255 ) , Color.FromArgb( 204 , 227 , 255 ) );
            p = new Pen( lgb , 2 );
            g.DrawLine( p , 0 , this.Height - 75 , this.Width , this.Height - 75 );

            p.Dispose();
            lgb.Dispose();




        }

        Graphics g;
        SolidBrush sb1;
        HatchBrush sb2;
        private void bStart_Click( object sender , EventArgs e )
        {
            Thread t = new Thread( delegate() {
                tbFoodX.Enabled = tbFoodY.Enabled = bStart.Enabled = bRandamize.Enabled = false;
                using( g = this.CreateGraphics() )
                {
                    startX = int.Parse( tbFoodX.Text );
                    startY = int.Parse( tbFoodY.Text );
                    CreateCells();
                    neighsFound = false;
                    sb1 = new SolidBrush( Color.Green );
                    sb2 = new HatchBrush( HatchStyle.DiagonalBrick , Color.Gainsboro , Color.GhostWhite );
                    SolveMaze( startY , startX );
                    sb1.Dispose();
                    sb2.Dispose();
                }
                tbFoodX.Enabled = tbFoodY.Enabled = bStart.Enabled = bRandamize.Enabled = true;
            } );
            t.Start();
        }
        bool neighsFound;
        private void SolveMaze( int i , int j )
        {
            int delay = 200;
            Stack<Cell> pathStack = new Stack<Cell>();
            Stack<Cell> nonVisitedNeighs = new Stack<Cell>();
            Cell peek;
            g.FillRectangle( sb1 , 33 + 35 * j , 33 + 35 * i , 30 , 30 );
            cells[i , j].visited = true;
            pathStack.Push( cells[i , j] );
            peek = pathStack.Peek();
            try
            {
                while( peek.i != foodY || peek.j != foodX )
                {
                    Thread.Sleep( delay );
                    //1.Load all Non Visited Neighbours of the peek element in the pathStack to the nonVisitedNeighs Stack....
                    peek = pathStack.Peek();
                    neighsFound = false;
                    if( peek.down == true )
                    {
                        if( cells[peek.i + 1 , peek.j].visited == false )
                        {
                            nonVisitedNeighs.Push( cells[peek.i + 1 , peek.j] );
                            neighsFound = true;
                        }
                    }
                    if( peek.top == true )
                    {
                        if( cells[peek.i - 1 , peek.j].visited == false )
                        {
                            nonVisitedNeighs.Push( cells[peek.i - 1 , peek.j] );
                            neighsFound = true;
                        }
                    }
                    if( peek.left == true )
                    {
                        if( cells[peek.i , peek.j - 1].visited == false )
                        {
                            nonVisitedNeighs.Push( cells[peek.i , peek.j - 1] );
                            neighsFound = true;
                        }
                    }
                    if( peek.right == true )
                    {
                        if( cells[peek.i , peek.j + 1].visited == false )
                        {
                            nonVisitedNeighs.Push( cells[peek.i , peek.j + 1] );
                            neighsFound = true;
                        }
                    }
                    //If no neighbours found, pop the peek elements from the pathStack until a peek elements have neighbours....
                    if( !neighsFound )
                    {
                        do
                        {
                            peek = pathStack.Pop();
                            Thread.Sleep( delay );
                            g.FillRectangle( sb2 , 33 + 35 * peek.j , 33 + 35 * peek.i , 30 , 30 );

                            neighsFound = false;
                            peek = pathStack.Peek();
                            if( peek.down == true )
                            {
                                if( cells[peek.i + 1 , peek.j].visited == false )
                                    neighsFound = true;
                            }
                            if( peek.top == true )
                            {
                                if( cells[peek.i - 1 , peek.j].visited == false )
                                    neighsFound = true;
                            }
                            if( peek.left == true )
                            {
                                if( cells[peek.i , peek.j - 1].visited == false )
                                    neighsFound = true;
                            }
                            if( peek.right == true )
                            {
                                if( cells[peek.i , peek.j + 1].visited == false )
                                    neighsFound = true;
                            }
                        } while( !neighsFound );
                    }
                    //2.
                    peek = nonVisitedNeighs.Pop();
                    g.FillRectangle( sb1 , 33 + 35 * peek.j , 33 + 35 * peek.i , 30 , 30 );
                    peek.visited = true;
                    pathStack.Push( peek );

                }
                MessageBox.Show( "Found the path to food......" , "Mazer" );
                DrawBorn2Code();
            }
            catch( InvalidOperationException ioe )
            {
                MessageBox.Show( "Food cannot be reached......!!" , "Mazer" );
            }
        }

        private void DrawBorn2Code()
        {
            int sleep = 150;
            Thread t = new Thread( delegate() {
                lBorn2Code.Text = "10000110011";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "B1000011001";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Bo100001100";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Bor10000110";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born1000011";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 100001";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 210000";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 2 1000";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 2 C100";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 2 Co10";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 2 Cod1";
                Thread.Sleep( sleep );
                lBorn2Code.Text = "Born 2 Code";
                Thread.Sleep( sleep );
            } );
            t.Start();
        }

        private void bRandamize_Click( object sender , EventArgs e )
        {

            Random r = new Random();
            for( int i = 0 ; i < col.GetLength( 0 ) ; i++ )
                for( int j = 0 ; j < col.GetLength( 1 ) ; j++ )
                    col[i , j] = r.Next( 2 );

            for( int i = 0 ; i < row.GetLength( 0 ) ; i++ )
                for( int j = 0 ; j < row.GetLength( 1 ) ; j++ )
                    row[i , j] = r.Next( 2 );

            foodX = r.Next( MazeGlobalProperties.MaxCells );
            foodY = r.Next( MazeGlobalProperties.MaxCells );

            this.Invalidate();

        }



        private void pictureBox1_Click( object sender , EventArgs e )
        {
            Process.Start( "http://vineelkumarreddy.googlepages.com" );
        }

        private void pbAbout_Click( object sender , EventArgs e )
        {
            MessageBox.Show( "Mazer By K.Vineel Kumar Reddy in C#\n\n\n                   BORN 2 CODE\n\n" , "Good Bye...." );

        }

        private void tbFoodX_Validated( object sender , EventArgs e )
        {
            int x;
            try
            {
                x = int.Parse( tbFoodX.Text );
                if( x >= 0 && x < MazeGlobalProperties.MaxCells ) ;
                else
                {
                    MessageBox.Show( "Entered number is not in valid range yaar....!!" , "Mazer" );
                    tbFoodX.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show( "Entered number is not valid yaar....!!" , "Mazer" );
                tbFoodX.Text = "0";
            }
        }

        private void tbFoodY_Validated( object sender , EventArgs e )
        {
            int y;
            try
            {
                y = int.Parse( tbFoodY.Text );
                if( y >= 0 && y < MazeGlobalProperties.MaxCells ) ;
                else
                {
                    MessageBox.Show( "Entered number is not in valid range yaar....!!" , "Mazer" );
                    tbFoodY.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show( "Entered number is not valid yaar....!!" , "Mazer" );
                tbFoodY.Text = "0";
            }
        }
    }
    class Cell
    {
        public bool left , right , top , down , visited;
        public int i , j;
    }
}
