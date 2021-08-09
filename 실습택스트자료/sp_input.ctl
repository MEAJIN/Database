 load data
  infile sp_blank.txt
  replace
  into table sp
  fields terminated by ' '
  (s# char,
   p# char,
   qty integer external)
