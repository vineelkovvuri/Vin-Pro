
--this function returns true if the title is deleted successfully, false otherwise
create or replace function DeleteTitle(tid integer) 
return boolean is 
PRAGMA AUTONOMOUS_TRANSACTION;
begin 
	delete from titles where titleid = tid;
	if sql%found then
		commit;
		return true;  -- if id is found and the delete command is successfully completed;
	else 
		return false; -- if id is not found
	end if;

	exception 		  -- if child record are present in titleauthors table	
	when others then
		return false;
end;
/

