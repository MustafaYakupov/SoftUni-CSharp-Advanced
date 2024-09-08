import java.util.*;

public class P23AverageGrades {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Student> students = new ArrayList<>();
        int studentsCount = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < studentsCount; i++) {
            String[] tokens = scanner.nextLine().split(" ");

            String name = tokens[0];
            Double[] grades = Arrays.stream(tokens)
                    .skip(1)
                    .map(Double::parseDouble)
                    .toArray(Double[]::new);

            Student student = new Student() {{
                setName(name);
                setGrades(Arrays.asList(grades));
            }};

            students.add(student);
        }
        Student[] filteredStudents = students.stream()
                .filter(s -> s.getAverageGrade() >= 5.00)
                .sorted(Comparator.comparing(Student::getName).thenComparingDouble(Student::getAverageGrade))
                .toArray(Student[]::new);

        for (Student student : filteredStudents) {
            System.out.printf("%s -> %.2f%n", student.getName(), student.getAverageGrade());
        }
    }
}
