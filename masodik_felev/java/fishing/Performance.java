package fishing;

import java.time.LocalDate;
import java.util.Objects;

public class Performance {
    private final String festival;
    private final LocalDate date;
    private final String weekday;
    private final String place;
    private final String startTime;
    private final String artist;
    private final String comment;
    private final int importanceLevel;
    private final int performanceFeeHuf;
    private final ProgramType programType;
    private final boolean confirmed;

    public Performance(String festival, LocalDate date, String weekdayHu, String weekdayEn,
            String stage, String startTime, String performer, String note,
            int importanceLevel, int performanceFeeHuf,
            ProgramType programType, boolean confirmed) {
        this.festival = festival;
        this.date = date;
        this.weekdayHu = weekdayHu;
        this.weekdayEn = weekdayEn;
        this.stage = stage;
        this.startTime = startTime;
        this.performer = performer;
        this.note = note;
        this.importanceLevel = importanceLevel;
        this.performanceFeeHuf = performanceFeeHuf;
        this.programType = programType;
        this.confirmed = confirmed;
    }

    public String getFestival() {
        return festival;
    }

    public LocalDate getDate() {
        return date;
    }

    public String getWeekdayHu() {
        return weekdayHu;
    }

    public String getWeekdayEn() {
        return weekdayEn;
    }

    public String getStage() {
        return stage;
    }

    public String getStartTime() {
        return startTime;
    }

    public String getPerformer() {
        return performer;
    }

    public String getNote() {
        return note;
    }

    public int getImportanceLevel() {
        return importanceLevel;
    }

    public int getPerformanceFeeHuf() {
        return performanceFeeHuf;
    }

    public ProgramType getProgramType() {
        return programType;
    }

    public boolean isConfirmed() {
        return confirmed;
    }

}
