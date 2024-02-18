declare 
a integer:=100; -- this is a number 
begin



	while a <1000 loop
		dbms_output.put_line(a);
		a:=a+1;
	end loop;
/*
	if a=10 then
		dbms_output.put_line('Ten');
	elsif a=20 then
		dbms_output.put_line('Twenty');
	else 
		dbms_output.put_line('Else');
	end if;
*/

end;
/

