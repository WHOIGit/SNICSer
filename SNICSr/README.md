# SNICSr

##### Project Information
- TBD

##### MICADS Integration
- To read the external MICADAS database, a user account needs to becreated in the MariaDB provided by MICADS. The user only requires acces to the `workproto_v_nt` table in the `db_ac14` database. A user can be created using the following:
```sql
create user 'username'@'%' identified by 'password';
grant select on db_ac14.workproto_v_nt to 'nosams'@'%';
flush privileges;
```