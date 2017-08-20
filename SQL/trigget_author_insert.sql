

create or replace trigger trg_author_insert
before insert
on titleauthors
for each row
declare
nauth number(4):=0;
begin
	select count(*) into nauth from titleauthors where titleid = :new.titleid;
	if nauth >=3 then
		raise_application_error(-20100,'Insertion failed : No of authors morethan 3');
	end if;
end;
/
