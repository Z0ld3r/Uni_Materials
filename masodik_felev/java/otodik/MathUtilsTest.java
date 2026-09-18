package otodik;

class MathUtilsTest {

    @Test
    void testSquare() {
        assertEquals(25, MathUtils.square(5));
        assertEquals(9, MathUtils.square(3));
        assertEquals(121, MathUtils.square(11));
    }

    @Test
    void testIsEven() {
        assertTrue(MathUtils.isEven(4));
        assertFalse(MathUtils.isEven(3));
        assertTrue(MathUtils.isEven(1245212));
    }

    @Test
    void testMax(){
        assertEquals(10, MathUtils.max(10, 5));
        assertEquals(11, MathUtils.max(10, 11));
        assertEquals(1, MathUtils.max(0, 1));
    }
}