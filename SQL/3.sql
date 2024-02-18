SET serveroutput ON
DECLARE
  tmax INTEGER:=0;
  tmin INTEGER:=0;
  tid titles.titleid%type;
  maxid INTEGER:=0;
BEGIN
   SELECT MIN(titleid),MAX(titleid) INTO tmin,tmax FROM titles;
  
  FOR id IN tmin .. tmax
  LOOP
    BEGIN
       SELECT titleid INTO tid FROM titles WHERE titleid=id;
    EXCEPTION
    WHEN no_data_found THEN
      IF maxid < id THEN
        maxid := id;
      END IF;
    END;
  END LOOP;
  dbms_output.put_line('Maximum missing title id is '||maxid);
END;
/

