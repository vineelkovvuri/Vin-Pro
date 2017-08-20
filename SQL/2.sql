SET serveroutput ON
DECLARE
  tmax       INTEGER:=0;
  tmin       INTEGER:=0;
  titlecount INTEGER:=0;
  maxid      INTEGER:=0;
BEGIN

   SELECT MIN(titleid),MAX(titleid) INTO tmin,tmax FROM titles;
  
  FOR id IN tmin .. tmax
  LOOP
     SELECT COUNT(*) INTO titlecount FROM titles WHERE titleid=id;
    -- if an id is not found and the its id > the previous maxid
    IF titlecount=0 AND maxid < id THEN
      maxid     := id;
    END IF;
  END LOOP;
  dbms_output.put_line('Maximum missing title id is '||maxid);
  
END;
/

