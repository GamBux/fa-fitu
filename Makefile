CC = tsc
TARGETS = register.js

%.js : %.ts
	$(CC) $<

all: $(TARGETS)

distclean:
	rm -f *.js
	
