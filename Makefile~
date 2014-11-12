CC = tsc
TARGETS = greeter.js

%.js : %.ts
	$(CC) $<

all: $(TARGETS)

distclean:
	rm -f *.js