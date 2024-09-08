import java.util.List;

public class Student {
    private String name;
    private List<Double> grades;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Double> getGrades() {
        return grades;
    }

    public void setGrades(List<Double> grades) {
        this.grades = grades;
    }

    public Double getAverageGrade() {
        double averageGrade = this.grades
                .stream()
                .mapToDouble(a -> a)
                .average()
                .getAsDouble();
        return averageGrade;
    }

}
