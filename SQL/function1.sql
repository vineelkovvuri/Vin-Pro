
--this function returns the title present at the offset given by the user
create or replace function GetTitle(position integer) 
return varchar2 is 
cursor pcur is
select title from titles;

begin 
	for prec in pcur
	loop
		if pcur%rowcount = position then
			return prec.title;
		end if;
	end loop;
end;

/

