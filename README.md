# FizzBuzz

Take the max number and divisors dynamically to generate the classic FizzBuzz sequence.

Things I have done:
- Create FizzBuzz singleton service and register to container (dependecy injection)
- Create FizzBuzz api to consume request and return result by json
- Create unit test project to test FizzBuzz service
- Use angular as the frontend framework and implement simple UI by using some modern CSS styles (flexbox, animation, ...)
- Use npm to install additional libraries such as FontAwesome
- Use angular reactive form to control the html form elements
- Call FizzBuzz api by HttpClient

Things can improve:
- Exception handling
- Custom form validation
- Modulize UI to small, reusable components. For example, move FizzBuzz form elements as FizzBuzzForm component and result panel as TerminalLikeLayout component.
- Frontend unit test cases.
