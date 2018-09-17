// Program to find the intersection of two rectangles which are xy-axis aligned

// 16-06-2016 09:06:24 PM

#include <iostream>

using namespace std;

struct rect {
	int x1, y1; // top left corner of the rectangle
	int x2, y2; // bottom right corner of the rectangle
};

#define max(x, y) ((x) > (y) ? (x) : (y))
#define min(x, y) ((x) < (y) ? (x) : (y))

int is_intersect(struct rect* r1, struct rect* r2)
{
	return !(r1->x2 <= r2->x1 || // r1 is completely left of r2 - right side of r1 does not touch left side of r2
			 r1->x1 >= r2->x2 || // r1 is completely right of r2 - right side of r2 does not touch left side of r1
			 r1->y2 <= r2->y1 || // r1 is completely above of r2 - bottom side of r1 does not touch top side of r2
			 r1->y1 >= r2->y2);  // r1 is completely below of r2 - bottom side of r2 does not touch top side of r1
}

struct rect get_intersect(struct rect* r1, struct rect* r2)
{
	struct rect temp = {0};
	
	if (is_intersect(r1, r2)) {
		temp.x1 = max(r1->x1, r2->x1);
		temp.y1 = max(r1->y1, r2->y1);
		temp.x2 = min(r1->x2, r2->x2);
		temp.y2 = min(r1->y2, r2->y2);
	}
	
	return temp;
}

int intersecting_rectangles()
{
	struct rect r1 = {0};
	struct rect r2 = {0};
	struct rect inter = {0};
	
	cout << "\nEnter first rectangle top left and bottom right coordinates:";
	cin >> r1.x1 >> r1.y1 >> r1.x2 >> r1.y2;
	cout << "\nEnter second rectangle top left and bottom right coordinates:";
    cin >> r2.x1 >> r2.y1 >> r2.x2 >> r2.y2;
	
	inter = get_intersect(&r1, &r2);
	cout << "Intersecting rectangle is : " << inter.x1 << " " << inter.y1 << " " << inter.x2 << " " << inter.y2;
	return 0;
}
