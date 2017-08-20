

set serveroutput on
begin
	if deletetitle(1001) then
		dbms_output.put_line('true');
	else 
		dbms_output.put_line('false');	
	end if;
end;
/
