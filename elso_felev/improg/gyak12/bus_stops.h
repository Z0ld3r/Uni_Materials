#ifndef BUS_STOPS
#define BUS_STOPS

define int MAP_SIZE = 10;

typedef struct {
    char* name;
    int x;
    int y;
} BusStop;

typedef struct{
    int count;
    BusStop* bus_stops;
} BusStops;

#endif