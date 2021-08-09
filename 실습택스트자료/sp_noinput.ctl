 load data
  infile *
  replace
  into table sp
  fields terminated by ','
  (s# char,
   p# char,
   qty integer external)
