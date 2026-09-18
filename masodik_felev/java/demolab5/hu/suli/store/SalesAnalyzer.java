package hu.suli.store;

import hu.suli.store.DayType;

public class SalesAnalyzer {
    private int[] sales;
    private DayType[] dayTypes;

    public SalesAnalyzer(int[] sales, DayType[] dayTypes) {
        this.sales = sales;
        this.dayTypes = dayTypes;
    }

    public int getTotalSales() {
        int sum = 0;
        for (int sale : sales) {
            sum += sale;
        }
        return sum;
    }

    public int countWeekendDays() {
        int count = 0;
        for (DayType type : dayTypes) {
            if (type == DayType.WEEKEND) {
                count++;
            }
        }
        return count;
    }

    public int getMaxSale() {
        int max = sales[0];
        for (int sale : sales) {
            if (sale > max) {
                max = sale;
            }
        }
        return max;
    }

    public boolean hasSaleOver(int limit) {
        for (int sale : sales) {
            if (sale > limit) {
                return true;
            }
        }
        return false;
    }
}