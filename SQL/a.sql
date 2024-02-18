declare
titlecount integer;
recenttitle titles.title%type;
begin
	--selecting the number of titles written by the author with id 102
	select count(*) into titlecount from titles t,titleauthors ta,authors a  where t.titleid = ta.titleid and ta.auid = a.auid and a.auid=102;
	dbms_output.put_line('Titles written by author id 102 are '||titlecount);

	--select the title written by the                    author 102 with recent pubdate 
	select title into recenttitle from titles where pubdate = (select max(pubdate) from titles t, titleauthors ta, authors a where t.titleid = ta.titleid and ta.auid = a.auid and a.auid=102);
	dbms_output.put_line('Recent title is '||recenttitle);
end;
/

