package arrays;

public class MyArrays {


    public static void zero_matrix_row_column(int mat[][])
    {
        int rows[] = new int[mat.length];
        int cols[] = new int[mat.length];

        for (int i = 0; i < mat.length; i++) {
            for (int j = 0; j < mat[i].length; j++) {
                if (mat[i][j] == 0) {
                    rows[i] = 1;
                    cols[j] = 1;
                }
            }
        }

        for (int i = 0; i < rows.length; i++) {
            if (rows[i] == 1) {
                for (int k = 0; k < rows.length; k++) {
                    mat[i][k] = 0;
                }
            }
        }

        for (int i = 0; i < rows.length; i++) {
            if (cols[i] == 1) {
                for (int k = 0; k < rows.length; k++) {
                    mat[k][i] = 0;
                }
            }
        }

        System.out.println();

        for (int i = 0; i < mat.length; i++) {
            for (int j = 0; j < mat.length; j++) {
                System.out.print(mat[i][j] + " ");
            }
            System.out.println();
        }
        System.out.println();

    }

    public static String run_length_encoding(String text) {
        String result = "";
        int count = 1;

        for (int i = 0; i < text.length(); i++) {
            if (i + 1 == text.length() || text.charAt(i) != text.charAt(i + 1)) {
                result += text.charAt(i) + "" + count;
                count = 1;
            } else {
                count++;
            }
        }

        return result;
    }
    public static void main(String[] args) {

//        int mat[][] = {
//                {1,2,3,4,5},
//                {1,2,3,4,5},
//                {1,0,3,4,5},
//                {1,2,3,4,5},
//                {1,2,3,0,5},
//        };
//        zero_matrix_row_column(mat);


//        String text = "aabbbbccddaaa";
//        String compressed_text = run_length_encoding(text);
//        System.out.println(compressed_text);
    }
}
