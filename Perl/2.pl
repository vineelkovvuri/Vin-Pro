#!/usr/bin/perl 

@arr = (10,2,4,5,1,9,7,8);

for($i=0;$i<@arr;$i++)
{
	for($j=0;$j<@arr-$i-1;$j++)
	{
			($arr[$j],$arr[$j+1]) = ($arr[$j+1],$arr[$j])if(@arr[$j]>@arr[$j+1]);
	}
}

foreach (@arr)
{
	print $_." "
}
