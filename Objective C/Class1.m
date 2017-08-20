#import <Foundation/Foundation.h>


@interface Fraction:NSObject
{
	int num;
	int denum;
}

-(void) print;
-(void) setNum: (int) n;
-(void) setDeNum: (int) n;

@end


@implementation Fraction 

-(void) print
{
	NSLog(@" the fraction is %i/%i",num,denum);
}

-(void) setNum: (int) n
{
	num = n;
}
-(void) setDeNum: (int) n
{
	denum = n;
}

@end 

int main (int argc, const char * argv[])
{
	NSAutoreleasePool * pool = [[NSAutoreleasePool alloc] init];
	
	Fraction *f = [[Fraction alloc] init];
	
	[f setNum:10];
	[f setDeNum:20];
	[f print];
	
	[f release];
	[pool drain];
	
	return 0;
}